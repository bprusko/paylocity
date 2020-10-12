using System.Collections.Generic;
using Paylocity.Api.ViewModels;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Models;
using DependentModel = Paylocity.Api.Models.Dependent;
using EmployeeVM = Paylocity.Api.ViewModels.Employee;
using DependentVM = Paylocity.Api.ViewModels.Dependent;

namespace Paylocity.Api.Services
{
    public class PaycheckService : IPaycheckService
    {
        private ICalculationService _calculationService;

        public PaycheckService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public Paycheck GetPaycheck(PaycheckRequest request)
        {
            var feeInfo = BuildPaycheck(request);
            return feeInfo;
        }

        private Paycheck BuildPaycheck(PaycheckRequest request)
        {
            var paycheck = new Paycheck();
            paycheck.Employee = BuildEmployeeInfo(request);
            paycheck.Dependents = BuildDependentsInfo(request);
            return paycheck;
        }

        private EmployeeVM BuildEmployeeInfo(PaycheckRequest request)
        {
            if (request?.Employee != null)
            {
                var employeeFees = _calculationService.CalculateDeductions(request.Employee);
                var employeeVM = new EmployeeVM
                {
                    FirstName = request.Employee.FirstName,
                    LastName = request.Employee.LastName,
                    Deductions = new ViewModels.Deduction
                    {
                        Discount = employeeFees.Discount,
                        Gross = employeeFees.Gross
                    }
                };
                return employeeVM;
            }

            return new EmployeeVM();
        }

        private List<DependentVM> BuildDependentsInfo(PaycheckRequest request)
        {
            var dependentsVM = new List<DependentVM>();

            if (request?.Dependents != null)
            {
                foreach (var depdendent in request.Dependents)
                {
                    dependentsVM.Add(BuildDependentInfo(depdendent));
                }
            }

            return dependentsVM;
        }

        private DependentVM BuildDependentInfo(DependentModel depdendent)
        {
            var depdendentFees = _calculationService.CalculateDeductions(depdendent);
            var depdendentVM = new DependentVM
            {
                FirstName = depdendent.FirstName,
                LastName = depdendent.LastName,
                Deductions = new ViewModels.Deduction
                {
                    Discount = depdendentFees.Discount,
                    Gross = depdendentFees.Gross
                }
            };
            return depdendentVM;
        }

        /* private Deduction BuildDeductionTotals(EmployeeVM employee, List<DependentVM> dependents)
        {
            var dependentDiscounts = dependents.Select(d => d.Deductions.Discount).Sum();
            var dependentGross = dependents.Select(d => d.Deductions.Gross).Sum();
            var dependentNet = dependents.Select(d => d.Deductions.Net).Sum();

            var deductionTotals = new Deduction
            {
                Discount = employee.Deductions.Discount + dependentDiscounts,
                Gross = employee.Deductions.Gross + dependentGross,
                Net = employee.Deductions.Net + dependentNet
            };

            return deductionTotals;
        } */

    }

}