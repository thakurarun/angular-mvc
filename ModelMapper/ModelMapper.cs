using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbModel = DataLayer.Database;
namespace ModelMapper
{
    public class ModelMapper
    {
        public static void MapModels()
        {
            Mapper.CreateMap<WebModel.User.UserModel, DbModel.User>();
            Mapper.CreateMap<WebModel.Account.AccountModel, DbModel.Account>();

            Mapper.CreateMap<WebModel.ResultSet, DataLayer.ResultSet>();
            Mapper.CreateMap<DataLayer.ResultSet, WebModel.ResultSet>();
            
        }
    }
}
