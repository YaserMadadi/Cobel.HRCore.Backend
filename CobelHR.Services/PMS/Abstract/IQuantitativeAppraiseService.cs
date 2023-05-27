using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IQuantitativeAppraiseService : IService<QuantitativeAppraise>
    {
        public DataResult<List<QuantitativeItemType>> CollectionOfQuantitativeItemType(int quantitativeAppraise_Id, QuantitativeItemType quantitativeItemType, UserCredit userCredit);
    }
}
