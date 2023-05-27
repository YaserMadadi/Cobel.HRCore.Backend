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

namespace CobelHR.Services.PMS
{
    public class QuantitativeAppraiseService : Service<QuantitativeAppraise>, IQuantitativeAppraiseService
    {
        public QuantitativeAppraiseService() : base()
        {
        }

        public override async Task<DataResult<QuantitativeAppraise>> SaveAttached(QuantitativeAppraise quantitativeAppraise, UserCredit userCredit)
        {
            return await quantitativeAppraise.SaveAttached(userCredit);
        }

        public DataResult<List<QuantitativeItemType>> CollectionOfQuantitativeItemType(int quantitativeAppraise_Id, QuantitativeItemType quantitativeItemType, UserCredit userCredit)
        {
            var procedureName = "[PMS].[QuantitativeAppraise.CollectionOfQuantitativeItemType]";

            return this.CollectionOf<QuantitativeItemType>(procedureName,
                                                    new SqlParameter("@Id", quantitativeAppraise_Id),
                                                    new SqlParameter("@User_Id", userCredit.Person_Id),
                                                    new SqlParameter("@jsonValue", quantitativeItemType.ToJson()));
        }


    }
}