﻿using Practice.Model;
using Practice.Common.Interfaces;

using Prism.Commands;

namespace PracticeViewModel.Interfaces
{
    public interface ICreateCharacterViewModel : IViewModel
    {
        DelegateCommand RollCommand { get; }
        DelegateCommand SaveCommand { get; }
        DelegateCommand RenameCommand { get; }

        Character Character { get; set; }
    }
}
