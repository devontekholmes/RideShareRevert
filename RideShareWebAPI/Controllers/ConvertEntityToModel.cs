using System;
using System.Collections.Generic;
using System.Linq;
using DM = RideShareWebAPI.Models;
using System.Web;

namespace RideShareWebAPI.Controllers
{
    public static class ConvertEntityToModel
    {
        public static DM.Customer CustomerToModel(RideShare.DAL.Customer entity)
        {
            DM.Customer result = new Models.Customer(entity.Email, entity.Password, entity.Name, entity.PhoneNo, entity.XCoordinate, entity.YCoordinate);
            return result;
        }
    }
}