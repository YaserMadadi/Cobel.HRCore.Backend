using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class QuantitativeItemType: EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "QuantitativeItemType", "QuantitativeItemType");

        #region Constructor
        public QuantitativeItemType() : this(0)
        {

        }

        public QuantitativeItemType(int id) : this(id, default)
        {

        }

        public QuantitativeItemType(int id, byte[] timeStamp) : base(id, timeStamp, QuantitativeItemType.Informer)
        {

        }

        #endregion

        #region Properties


        public string Title { get; set; }
        
        public bool? IsActive { get; set; }

        #endregion

        #region    List Of Related Entities

        #endregion
        
        public override bool Validate()
        {
            return Title.Validate() &&
                    IsActive.Validate();
        }

    }
}
