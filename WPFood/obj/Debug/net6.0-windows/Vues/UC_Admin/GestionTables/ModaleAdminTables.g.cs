﻿#pragma checksum "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C02A6BCA2A54CAD865A3C8F09DAFA939EAC3FC15"
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
using WPFood.Vues.UC_Admin.GestionTables;


namespace WPFood.Vues.UC_Admin.GestionTables {
    
    
    /// <summary>
    /// ModaleAdminTables
    /// </summary>
    public partial class ModaleAdminTables : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ModaleType;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNbPlaceMax;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjoutModif;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFood;component/vues/uc_admin/gestiontables/modaleadmintables.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
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
            this.ModaleType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tbNbPlaceMax = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnAjoutModif = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
            this.btnAjoutModif.Click += new System.Windows.RoutedEventHandler(this.BtnAjoutModif_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 84 "..\..\..\..\..\..\Vues\UC_Admin\GestionTables\ModaleAdminTables.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAnnuler_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
