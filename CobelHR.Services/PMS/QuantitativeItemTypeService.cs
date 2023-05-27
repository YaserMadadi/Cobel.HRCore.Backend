using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;
using EssentialCore.DataAccess;

namespace CobelHR.Services.PMS
{
    public class QuantitativeItemTypeService : Service<QuantitativeItemType>, IQuantitativeItemTypeService
    {
        public QuantitativeItemTypeService() : base()
        {

        }

        public override async Task<DataResult<QuantitativeItemType>> SaveAttached(QuantitativeItemType quantitativeItemType, UserCredit userCredit)
        {
            return await quantitativeItemType.SaveAttached(userCredit);
        }


    }
}