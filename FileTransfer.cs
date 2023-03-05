using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista_File_Mover
{
    public class Filter
    {
        public string[] filterStyles { get; private set; } = { "Contains", "Not Contains", "Extension"};

        public string filterSource { get; set; } = "Filename";
        public string filterStyle { get; set; }
        public string filterKey { get; set; }

        public Filter() 
        {
        }
    }
    
    public class FileTransfer
    {
        //Transfer name
        public string transferName { get; set; }

        //Transfer enable/disable
        public bool transferEnabled { get; set; } = true;
        
        //Source and destination directories
        public string source { get; set; }
        public string destination { get; set; }

        //Filters for file type and file names
        public BindingList<Filter> groupFilters { get; set; } = new BindingList<Filter>();
        public BindingList<Filter> copyFilters { get; set; } = new BindingList<Filter>();

        public FileTransfer() 
        {
        
        }

        public FileTransfer(string name)
        {
            this.transferName = name;
        }

        public FileTransfer(string name, bool enabled) 
        {
            this.transferName = name;
            this.transferEnabled = enabled;
        }
    }
}
