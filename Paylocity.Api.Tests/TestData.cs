using System.Collections.Generic;
using Paylocity.Api.Models;
using Dependent = Paylocity.Api.Models.Dependent;
using Employee = Paylocity.Api.Models.Employee;
using DependentVM = Paylocity.Api.ViewModels.Dependent;
using EmployeeVM = Paylocity.Api.ViewModels.Employee;
using DeductionVM = Paylocity.Api.ViewModels.Deduction;
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

        public static readonly Paycheck Paycheck = new Paycheck
        {
            Employee = new EmployeeVM
            {
                FirstName = "Meryl",
                LastName = "Hunter",
                Deductions = new DeductionVM
                {
                    Discount = 0,
                    Gross = 38.46
                }
            },
            Dependents = new List<DependentVM> {
                new DependentVM {
                FirstName = "Dorothy",
                LastName = "Hunter",
                Deductions = new DeductionVM {
                    Discount = 0,
                    Gross = 19.23
                    }
                }
            }
        };

        public static readonly Dependent DependentWithDiscount = new Dependent
        {
            FirstName = "Astrid",
            LastName = "Levinson"
        };

        public static readonly DeductionsRequest PaycheckRequestWithDependents = new DeductionsRequest
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

        public static readonly DeductionsRequest PaycheckRequest = new DeductionsRequest
        {
            Employee = new Employee
            {
                FirstName = "Michael",
                LastName = "Scott"
            }
        };

        public static readonly Models.Deduction EmployeeFeesWithDiscount = new Models.Deduction
        {
            Discount = 3.85,
            Gross = 38.46
        };

        public static readonly Models.Deduction EmployeeDeductions = new Models.Deduction
        {
            Discount = 0,
            Gross = 38.46
        };

        public static readonly Models.Deduction DependentDeductionsWithDiscount = new Models.Deduction
        {
            Discount = 1.92,
            Gross = 19.23
        };

        public static readonly Models.Deduction DependentDeductions = new Models.Deduction
        {
            Discount = 0,
            Gross = 19.23
        };

    }

}