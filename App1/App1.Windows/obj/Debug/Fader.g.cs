﻿

#pragma checksum "C:\Users\Daniel\Documents\Visual Studio 2013\Projects\App1\App1\App1.Shared\Fader.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E181A1A95447853A13DC4A5EBB1A790B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gnow.UI
{
    partial class Fader : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 25 "..\..\Fader.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.RangeBase)(target)).ValueChanged += this.Slider_ValueChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


