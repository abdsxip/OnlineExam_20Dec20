using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class Centre
    {
        #region Properties

        public int CentreId { get; set; }

       
        public Region CentreRegion
        {
            get
            {
                if (_centreRegion == null)
                {
                    _centreRegion = new Region();
                }
                return _centreRegion;
            }
            set
            {
                _centreRegion = value;
            }
        }

      


        public string CentreName { get; set; }

      
        public string CentreIds { get; set; }

       
        public string FranchiseeName { get; set; }

       
        public string CentreCode { get; set; }

       
        public string ShortCode { get; set; }

       
        public bool IsFranchisee { get; set; }

       
        public string CentreAddress { get; set; }

       
        public string CentrePhone { get; set; }

       
        public string CentreMobile { get; set; }

       
        public string AMmobileNo { get; set; }

      
        public string RMmobileNo { get; set; }
      
        public string RManager { get; set; }

      
        public string CentreContactPerson { get; set; }

      
        public string CentreContactAddress { get; set; }

      
        public string CentreContactPhone { get; set; }

      
        public string CentreContactMobile { get; set; }

        public string CentreEmailId { get; set; }

    
        public DateTime CentreAgreementDate { get; set; }

     
        public DateTime CentreAgreementValidTill { get; set; }

    
        public bool CentreIsActive { get; set; }

  
        public string CentrePanNo { get; set; }

        public string CentreServiceTaxNo { get; set; }

        public string CentreBankAccount { get; set; }

     public string CentreBankName { get; set; }

      
        public string CentreRoyalty { get; set; }

        public string CentreCity { get; set; }

 
        public decimal CentreBPShare { get; set; }

  
        public decimal CentreMktgComm { get; set; }


        public bool IsTaxApplicable { get; set; }


        public bool IsCustomPlan { get; set; }


        public string AMEmailId { get; set; }

 
        public string RMEmailId { get; set; }


        public string centreCurrency { get; set; }

        #endregion

        #region Private Variables
        private Region _centreRegion;      
        #endregion
    }
}
