using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteMvc.Models.Class
{
    public class DisplayonboardVessels
    {
      
            public int itemCount { get; set; }
            public int onboardID { get; set; }
            public string dateCreated { get; set; }
            public string vesselMnemonic { get; set; }
            public string vessleName { get; set; }
            public string voyageNo { get; set; }
            public string status { get; set; }
        
    }
}