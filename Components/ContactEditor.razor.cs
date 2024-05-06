﻿

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using NTouch.Pages;
using ObjectLibrary.Enumerations;
using DataAccessComponent.DataGateway;
using DataAccessComponent.Connection;
using DataJuggler.NET8;
using DataJuggler.NET8.Enumerations;

#endregion

namespace NTouch.Components
{

    #region class ContactEditor
    /// <summary>
    /// This class is used to add or edit contacts
    /// </summary>
    public partial class ContactEditor : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private List<IBlazorComponent> children;
        private ValidationComponent zipControl;
        private CalendarComponent lastContactedDateControl;
        private CalendarComponent followUpDateControl;
        private string title;
        private ComboBox stateComboBox;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an EditContact component
        /// </summary>
        public ContactEditor()
        {
            // Setup the Title
            Title = "Add Contact";
        }
        #endregion

        #region Methods
            
            #region Cancel()
            /// <summary>
            /// Cancel
            /// </summary>
            public void Cancel()
            {
                if (HasParentIndexPage)
                {
                    // Set the Index Page
                    ParentIndexPage.ScreenType = ScreenTypeEnum.IndexPage;

                    // Update the UI
                    ParentIndexPage.Refresh();
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method Find Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                 // probably not used
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                if (NullHelper.Exists(message))
                {
                    if (message.Text.Contains("text"))
                    {
                        // get the key pressed
                        string keyPressed = message.Text.Replace("text: Key", "");

                        // Filter the list of items
                        
                    }   
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is ValidationComponent)
                {
                    if (component.Name == "ZipControl")
                    {
                        // Store
                        ZipControl = component as ValidationComponent;
                    }
                }
                else if (component is CalendarComponent)
                {
                    if (component.Name == "LastContactedDateControl")
                    {
                        // Store
                        LastContactedDateControl = component as CalendarComponent;
                    }
                    else if (component.Name == "FollowUpDateControl")
                    {
                        // Store
                        FollowUpDateControl = component as CalendarComponent;
                    }
                }
                else if (component is ComboBox)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(Connection.Name);

                    // load the States
                    List<ObjectLibrary.BusinessObjects.State> states = gateway.LoadStates();

                    // Store
                    StateComboBox = component as ComboBox;

                    // if the value for HasStateComboBox is true
                    if (HasStateComboBox)
                    {
                        // Load the ComboBox
                        // StateComboBox.LoadItems(states);

                        StateComboBox.LoadItems(typeof(TargetFrameworkEnum));
                    }
                }
            }
            #endregion

            #region Save()
            /// <summary>
            /// Save
            /// </summary>
            public void Save()
            {
            }
            #endregion
            
            #region Cancel(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Cancel
            /// </summary>
            public void Cancel(object sender, EventArgs e)
            {
                
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region FollowUpCalendarControl
            /// <summary>
            /// This property gets or sets the value for 'FollowUpCalendarControl'.
            /// </summary>
            public CalendarComponent FollowUpDateControl
            {
                get { return followUpDateControl; }
                set { followUpDateControl = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasLastContactedDateControl
            /// <summary>
            /// This property returns true if this object has a 'LastContactedDateControl'.
            /// </summary>
            public bool HasLastContactedDateControl
            {
                get
                {
                    // initial value
                    bool hasLastContactedDateControl = (this.LastContactedDateControl != null);
                    
                    // return value
                    return hasLastContactedDateControl;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
                }
            }
            #endregion
            
            #region HasStateComboBox
            /// <summary>
            /// This property returns true if this object has a 'StateComboBox'.
            /// </summary>
            public bool HasStateComboBox
            {
                get
                {
                    // initial value
                    bool hasStateComboBox = (this.StateComboBox != null);
                    
                    // return value
                    return hasStateComboBox;
                }
            }
            #endregion
            
            #region HasZipControl
            /// <summary>
            /// This property returns true if this object has a 'ZipControl'.
            /// </summary>
            public bool HasZipControl
            {
                get
                {
                    // initial value
                    bool hasZipControl = (this.ZipControl != null);
                    
                    // return value
                    return hasZipControl;
                }
            }
            #endregion
            
            #region LastContactedDateControl
            /// <summary>
            /// This property gets or sets the value for 'LastContactedDateControl'.
            /// </summary>
            public CalendarComponent LastContactedDateControl
            {
                get { return lastContactedDateControl; }
                set { lastContactedDateControl = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            #endregion

            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value of ParentIndexPage from the object Parent.
            /// </summary>
            public IndexPage ParentIndexPage
            {
                
                get
                {
                    // initial value
                    IndexPage parentIndexPage = null;
                    
                    // if Parent exists
                    if (HasParent)
                    {
                        // set the return value
                        parentIndexPage = Parent as IndexPage;
                    }
                    
                    // return value
                    return parentIndexPage;
                }
            }
            #endregion
            
            #region StateComboBox
            /// <summary>
            /// This property gets or sets the value for 'StateComboBox'.
            /// </summary>
            public ComboBox StateComboBox
            {
                get { return stateComboBox; }
                set { stateComboBox = value; }
            }
            #endregion
            
            #region Title
            /// <summary>
            /// This property gets or sets the value for 'Title'.
            /// </summary>
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            #endregion
            
            #region ZipControl
            /// <summary>
            /// This property gets or sets the value for 'ZipControl'.
            /// </summary>
            public ValidationComponent ZipControl
            {
                get { return zipControl; }
                set { zipControl = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion
}