using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using gnow.util.behringer;

namespace gnow.util
{
    public class DetailPresenter : Presenter
    {
        public DetailPresenter(IDetailView view)
        {
            this.view = view;
            //TODO: Add console events and register this as a listener
        }
    }
}
