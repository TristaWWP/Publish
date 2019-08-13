using Cvte.EasiNote;
using Cvte.EasiNote.Extensions;
using Cvte.Paint.Features.Elements.Images;
using dotnetCampus.EasiPlugins;
using PublishHomework.Utilities;
using PublishHomework.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PublishHomework
{
    [LangExport("发布作业")]
    [UIItem(UIItemPurposes.ElementEditMenu)]
    public class Menu : ElementEditMenuItem, ICommand
    {
        public Menu()
        {
            SortHint = 144;
            Command = this;
            Predicate = (elements) => elements.Count <= 6 && elements.All(x => x is Picture);
        }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            var window = Window.GetWindow(EN.EditingBoardApi.Board);
            var pictures = EN.CurrentBoardApi.GetSelectedElements().OfType<Picture>();
            new UploadPicture(pictures.Select(x => x.Source.ToString()).ToList())
            {
                Owner = window
            }.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;
    }
}


