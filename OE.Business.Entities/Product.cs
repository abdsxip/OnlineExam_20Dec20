using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class Product : Module
    {

        #region properties
       
        public string ProductIds { get; set; }
      
        public string ProductName { get; set; }

        public List<Module> Modules
        {
            get
            {
                if (_modules == null)
                {
                    _modules = new List<Module>();
                }
                return _modules;
            }

            set
            {
                _modules = value;
            }
        }
        
        #endregion

        #region Private Variables
        private List<Module> _modules;       

        #endregion



    }
}
