﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.ViewModels;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.Services
{
    interface IWindowService
    {
        public void ShowWindow(ArmyShowView vm, Window parentWindow);
    }
}
