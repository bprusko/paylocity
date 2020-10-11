using System.Collections.Generic;
using Paylocity.Api.Models;
using Dependent = Paylocity.Api.Models.Dependent;
using Employee = Paylocity.Api.Models.Employee;
using DependentVM = Paylocity.Api.ViewModels.Dependent;
using EmployeeVM = Paylocity.Api.ViewModels.Employee;
using FeeTotalVM = Paylocity.Api.ViewModels.FeeTotal;
using Paylocity.Api.ViewModels;

namespace Paylocity.Api.Tests
{
    public class TestData
    {
        public static readonly Employee Employee = new Employee
        {
            FirstName = "Michael",
            LastName = "Scott"
        };

        public static readonly Employee EmployeeWithDiscount = new Employee
        {
            FirstName = "Angela",
            LastName = "Schrute"
        };

        public static readonly Dependent Dependent = new Dependent
        {
            FirstName = "Marty",
            LastName = "Jannetty"
        };

        public static readonly FeeInfo FeeInfo = new FeeInfo
        {
            Employee = new EmployeeVM
            {
                FirstName = "Meryl",
                LastName = "Hunter",
                FeeTotals = new FeeTotalVM {
                    Discount = 0,
                    Gross = 38.46,
                    Net = 38.46
                }
            },
            Dependents = new List<DependentVM> {
                new DependentVM {
                FirstName = "Dorothy",
                LastName = "Hunter",
                FeeTotals = new FeeTotalVM {
                    Discount = 0,
                    Gross = 19.23,
                    Net = 19.23
                    }
                }
            },
            FeeTotals = new FeeTotalVM {
                Discount = 0,
                Gross = 47.69,
                Net = 47.69
            }
        };

        public static readonly Dependent DependentWithDiscount = new Dependent
        {
            FirstName = "Astrid",
            LastName = "Levinson"
        };

        public static readonly FeesRequest FeesRequestWithDependents = new FeesRequest
        {
            Employee = new Employee
            {
                FirstName = "Michael",
                LastName = "Scott"
            },
            Dependents = new List<Dependent> {
                new Dependent {
                    FirstName = "Dependent1 - First Name",
                    LastName = "Dependent1 - Last Name",
                },
                new Dependent {
                    FirstName = "Dependent2 - First Name",
                    LastName = "Dependent2 - Last Name",
                }
            }
        };

        public static readonly FeesRequest FeesRequestWithoutDependents = new FeesRequest
        {
            Employee = new Employee
            {
                FirstName = "Michael",
                LastName = "Scott"
            }
        };

        public static readonly Fees EmployeeFeesWithDiscount = new Fees
        {
            Discount = 3.85,
            Gross = 38.46,
            Net = 34.61
        };

        public static readonly Fees EmployeeFees = new Fees
        {
            Discount = 0,
            Gross = 38.46,
            Net = 38.46
        };

        public static readonly Fees DependentFeesWithDiscount = new Fees
        {
            Discount = 1.92,
            Gross = 19.23,
            Net = 17.31
        };

        public static readonly Fees DependentFees = new Fees
        {
            Discount = 0,
            Gross = 19.23,
            Net = 19.23
        };

    }

}