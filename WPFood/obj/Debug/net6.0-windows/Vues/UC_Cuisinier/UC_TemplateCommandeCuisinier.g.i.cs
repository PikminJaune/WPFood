﻿#pragma checksum "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D79FBAB809D292E3E16D6E2FC8E93F6E58D3A56"
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
using WPFood.Vues.UC_Cuisinier;


namespace WPFood.Vues.UC_Cuisinier {
    
    
    /// <summary>
    /// UC_TemplateCommandeCuisinier
    /// </summary>
    public partial class UC_TemplateCommandeCuisinier : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label numeroTable;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCommandeCuisinier;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock heureCommander;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTerminer;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFood;component/vues/uc_cuisinier/uc_templatecommandecuisinier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
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
            this.numeroTable = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbCommandeCuisinier = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.heureCommander = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnTerminer = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\..\Vues\UC_Cuisinier\UC_TemplateCommandeCuisinier.xaml"
            this.btnTerminer.Click += new System.Windows.RoutedEventHandler(this.btn_ClickTerminer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
