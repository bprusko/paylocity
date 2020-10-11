using System.Collections.Generic;
using System.Linq;
using Paylocity.Api.ViewModels;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Models;
using DependentModel = Paylocity.Api.Models.Dependent;
using EmployeeVM = Paylocity.Api.ViewModels.Employee;
using DependentVM = Paylocity.Api.ViewModels.Dependent;

namespace Paylocity.Api.Services
{
    public class FeesService : IFeesService
    {
        private ICalculationService _calculationService;

        public FeesService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public FeeInfo GetFees(FeesRequest request)
        {
            var feeInfo = BuildFeeInfo(request);
            return feeInfo;
        }

        private FeeInfo BuildFeeInfo(FeesRequest request)
        {
            var feeInfo = new FeeInfo();
            feeInfo.Employee = BuildEmployeeFeeInfo(request);
            feeInfo.Dependents = BuildDependentsFeeInfo(request);
            feeInfo.FeeTotals = BuildFeeTotals(feeInfo.Employee, feeInfo.Dependents);
            return feeInfo;
        }

        private EmployeeVM BuildEmployeeFeeInfo(FeesRequest request)
        {
            if (request?.Employee != null)
            {
                var employeeFees = _calculationService.CalculateFees(request.Employee);
                var employeeVM = new EmployeeVM
                {
                    FirstName = request.Employee.FirstName,
                    LastName = request.Employee.LastName,
                    FeeTotals = new FeeTotal
                    {
                        Discount = employeeFees.Discount,
                        Gross = employeeFees.Gross,
                        Net = employeeFees.Net
                    }
                };
                return employeeVM;
            }

            return new EmployeeVM();
        }

        private List<DependentVM> BuildDependentsFeeInfo(FeesRequest request)
        {
            var dependentsVM = new List<DependentVM>();

            if (request?.Dependents != null)
            {
                foreach (var depdendent in request.Dependents)
                {
                    dependentsVM.Add(BuildDependentFeeInfo(depdendent));
                }
            }

            return dependentsVM;
        }

        private DependentVM BuildDependentFeeInfo(DependentModel depdendent)
        {
            var depdendentFees = _calculationService.CalculateFees(depdendent);
            var depdendentVM = new DependentVM
            {
                FirstName = depdendent.FirstName,
                LastName = depdendent.LastName,
                FeeTotals = new FeeTotal
                {
                    Discount = depdendentFees.Discount,
                    Gross = depdendentFees.Gross,
                    Net = depdendentFees.Net
                }
            };
            return depdendentVM;
        }

        private FeeTotal BuildFeeTotals(EmployeeVM employee, List<DependentVM> dependents)
        {
            var dependentDiscounts = dependents.Select(d => d.FeeTotals.Discount).Sum();
            var dependentGross = dependents.Select(d => d.FeeTotals.Gross).Sum();
            var dependentNet = dependents.Select(d => d.FeeTotals.Net).Sum();

            var feeTotals = new FeeTotal
            {
                Discount = employee.FeeTotals.Discount + dependentDiscounts,
                Gross = employee.FeeTotals.Gross + dependentGross,
                Net = employee.FeeTotals.Net + dependentNet
            };

            return feeTotals;
        }

    }

}