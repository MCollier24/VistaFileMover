﻿using System;
using System.ComponentModel;

namespace Vista_File_Mover
{
    #region Filter Class
    public class Filter
    {
        public static string[] filterStyles { get; private set; } = { "Contains", "Not Contains", "Extension"};

        public string filterSource { get; set; } = "Filename";
        public string filterStyle { get; set; } = filterStyles[0];
        public string filterKey { get; set; }

        public Filter() 
        {
        }

        public Boolean apply(string file)
        {
            if (filterSource == "Filename")
            {
                switch (filterStyle)
                {
                    case "Contains":
                        return file.ToLower().Contains(filterKey.ToLower());
                    case "Not Contains":
                        return !file.ToLower().Contains(filterKey.ToLower());
                    case "Extension":
                        return file.ToLower().EndsWith(filterKey.ToLower());
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Filter Clone()
        {
            return (Filter) this.MemberwiseClone();
        }
    }
    #endregion

    #region FileTransfer Class
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

        public FileTransfer Clone()
        {
            FileTransfer clonedTransfer = new FileTransfer(this.transferName, this.transferEnabled);

            clonedTransfer.source = this.source;
            clonedTransfer.destination = this.destination;

            foreach (Filter f in this.groupFilters)
                clonedTransfer.groupFilters.Add(f);

            foreach(Filter f in this.copyFilters)
                clonedTransfer.copyFilters.Add(f);

            return clonedTransfer;
        }
    }
    #endregion
}
