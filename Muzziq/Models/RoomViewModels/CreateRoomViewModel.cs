﻿using Muzziq.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Muzziq.Models.RoomViewModels
{
    public class CreateRoomViewModel
    {
        public List<Song> AvailableSongs { get; set; }
   

        public CreateRoomViewModel(List<Song> availableSongs)
        {            
            this.AvailableSongs = availableSongs;
        }

        public CreateRoomViewModel() {
            this.AvailableSongs = new List<Song>();
        }
    }
}
