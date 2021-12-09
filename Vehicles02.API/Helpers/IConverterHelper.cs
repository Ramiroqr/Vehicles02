using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles02.API.Data.Entities;
using Vehicles02.API.Models;

namespace Vehicles02.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);

        Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew);

        VehicleViewModel ToVehicleViewModel(Vehicle vehicle);

        Task<Detail> ToDetailAsync(DetailViewModel model, bool isNew);

        DetailViewModel ToDetailViewModel(Detail detail);
    }
}
