﻿#pragma checksum "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E16C840D3DE8750CA9F03232709C5F73F8FCF7B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFood.Vues;


namespace WPFood.Vues {
    
    
    /// <summary>
    /// UC_HoteTables
    /// </summary>
    public partial class UC_HoteTables : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 54 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LBTables;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBNbTables;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNbPlace;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBToutesLesTables;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBTablesLibres;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBTablesANettoyer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFood;component/vues/uc_hote/uc_hotetables.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Reservations_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LBTables = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.TBNbTables = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbNbPlace = ((System.Windows.Controls.TextBox)(target));
            
            #line 188 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            this.tbNbPlace.SelectionChanged += new System.Windows.RoutedEventHandler(this.TbNbPlaces_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 189 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            this.tbNbPlace.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RBToutesLesTables = ((System.Windows.Controls.RadioButton)(target));
            
            #line 232 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            this.RBToutesLesTables.Checked += new System.Windows.RoutedEventHandler(this.ToutesTables_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RBTablesLibres = ((System.Windows.Controls.RadioButton)(target));
            
            #line 248 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            this.RBTablesLibres.Checked += new System.Windows.RoutedEventHandler(this.TablesLibres_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RBTablesANettoyer = ((System.Windows.Controls.RadioButton)(target));
            
            #line 264 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            this.RBTablesANettoyer.Checked += new System.Windows.RoutedEventHandler(this.TablesNettoyage_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 4:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.MouseLeftButtonUpEvent;
            
            #line 116 "..\..\..\..\..\Vues\UC_Hote\UC_HoteTables.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseLeftButtonUp);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
