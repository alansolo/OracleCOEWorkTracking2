﻿using OracleCOEWorkTracking.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool DeleteMark { get; set; }

        public List<int> AppIds {get;set;}


        //public static List<RegionViewModel> getRegionVMList(IEnumerable<Region> data)
        //{

        //    List<RegionViewModel>  viewModels = data.Select(d => new RegionViewModel()
        //    {
        //        AppIds = d.AppRegions.Select(s => s.AppId).ToList(),
        //        CreatedBy = d.CreatedBy,
        //        CreatedOn = d.CreatedOn.ToShortDateString(),
        //        DeleteMark = d.DeleteMark,
        //        Id = d.Id,
        //        ModifiedBy = d.ModifiedBy,
        //        ModifiedOn = "",
        //        Name = d.Name
        //    }).ToList();
        //    return viewModels;
        //}
        
    }
}
