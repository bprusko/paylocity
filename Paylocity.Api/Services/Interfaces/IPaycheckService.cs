using Paylocity.Api.Models;
using Paylocity.Api.ViewModels;

namespace Paylocity.Api.Services.Interfaces {

    public interface IPaycheckService {

        Paycheck GetPaycheck(PaycheckRequest request);

    }

}