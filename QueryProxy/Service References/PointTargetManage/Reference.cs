﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueryProxy.PointTargetManage {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DZY_GGFW_DAMPEPOINTTARGET", Namespace="http://schemas.datacontract.org/2004/07/CommonService.Model")]
    [System.SerializableAttribute()]
    public partial class DZY_GGFW_DAMPEPOINTTARGET : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float ALLOWABLEVIRATIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DETECTNUMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DETECTTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LATITUDEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LONGTITUDEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRIORITYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PROPOSEPERSONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PROPOSETIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TARGETCODEField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float ALLOWABLEVIRATION {
            get {
                return this.ALLOWABLEVIRATIONField;
            }
            set {
                if ((this.ALLOWABLEVIRATIONField.Equals(value) != true)) {
                    this.ALLOWABLEVIRATIONField = value;
                    this.RaisePropertyChanged("ALLOWABLEVIRATION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DETECTNUM {
            get {
                return this.DETECTNUMField;
            }
            set {
                if ((object.ReferenceEquals(this.DETECTNUMField, value) != true)) {
                    this.DETECTNUMField = value;
                    this.RaisePropertyChanged("DETECTNUM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DETECTTIME {
            get {
                return this.DETECTTIMEField;
            }
            set {
                if ((object.ReferenceEquals(this.DETECTTIMEField, value) != true)) {
                    this.DETECTTIMEField = value;
                    this.RaisePropertyChanged("DETECTTIME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LATITUDE {
            get {
                return this.LATITUDEField;
            }
            set {
                if ((this.LATITUDEField.Equals(value) != true)) {
                    this.LATITUDEField = value;
                    this.RaisePropertyChanged("LATITUDE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LONGTITUDE {
            get {
                return this.LONGTITUDEField;
            }
            set {
                if ((this.LONGTITUDEField.Equals(value) != true)) {
                    this.LONGTITUDEField = value;
                    this.RaisePropertyChanged("LONGTITUDE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRIORITY {
            get {
                return this.PRIORITYField;
            }
            set {
                if ((this.PRIORITYField.Equals(value) != true)) {
                    this.PRIORITYField = value;
                    this.RaisePropertyChanged("PRIORITY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PROPOSEPERSON {
            get {
                return this.PROPOSEPERSONField;
            }
            set {
                if ((object.ReferenceEquals(this.PROPOSEPERSONField, value) != true)) {
                    this.PROPOSEPERSONField = value;
                    this.RaisePropertyChanged("PROPOSEPERSON");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PROPOSETIME {
            get {
                return this.PROPOSETIMEField;
            }
            set {
                if ((this.PROPOSETIMEField.Equals(value) != true)) {
                    this.PROPOSETIMEField = value;
                    this.RaisePropertyChanged("PROPOSETIME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TARGETCODE {
            get {
                return this.TARGETCODEField;
            }
            set {
                if ((object.ReferenceEquals(this.TARGETCODEField, value) != true)) {
                    this.TARGETCODEField = value;
                    this.RaisePropertyChanged("TARGETCODE");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DZY_GGFW_DAMPETask", Namespace="http://schemas.datacontract.org/2004/07/CommonService.Model")]
    [System.SerializableAttribute()]
    public partial class DZY_GGFW_DAMPETask : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ENDTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LATITUDEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LONGTITUDEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PLANIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string REMARKField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime STARTTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TASKIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VIEWTYPEField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ENDTIME {
            get {
                return this.ENDTIMEField;
            }
            set {
                if ((this.ENDTIMEField.Equals(value) != true)) {
                    this.ENDTIMEField = value;
                    this.RaisePropertyChanged("ENDTIME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float LATITUDE {
            get {
                return this.LATITUDEField;
            }
            set {
                if ((this.LATITUDEField.Equals(value) != true)) {
                    this.LATITUDEField = value;
                    this.RaisePropertyChanged("LATITUDE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float LONGTITUDE {
            get {
                return this.LONGTITUDEField;
            }
            set {
                if ((this.LONGTITUDEField.Equals(value) != true)) {
                    this.LONGTITUDEField = value;
                    this.RaisePropertyChanged("LONGTITUDE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PLANID {
            get {
                return this.PLANIDField;
            }
            set {
                if ((this.PLANIDField.Equals(value) != true)) {
                    this.PLANIDField = value;
                    this.RaisePropertyChanged("PLANID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string REMARK {
            get {
                return this.REMARKField;
            }
            set {
                if ((object.ReferenceEquals(this.REMARKField, value) != true)) {
                    this.REMARKField = value;
                    this.RaisePropertyChanged("REMARK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime STARTTIME {
            get {
                return this.STARTTIMEField;
            }
            set {
                if ((this.STARTTIMEField.Equals(value) != true)) {
                    this.STARTTIMEField = value;
                    this.RaisePropertyChanged("STARTTIME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TASKID {
            get {
                return this.TASKIDField;
            }
            set {
                if ((object.ReferenceEquals(this.TASKIDField, value) != true)) {
                    this.TASKIDField = value;
                    this.RaisePropertyChanged("TASKID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VIEWTYPE {
            get {
                return this.VIEWTYPEField;
            }
            set {
                if ((object.ReferenceEquals(this.VIEWTYPEField, value) != true)) {
                    this.VIEWTYPEField = value;
                    this.RaisePropertyChanged("VIEWTYPE");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.artech.com", ConfigurationName="PointTargetManage.PointTaskManage")]
    public interface PointTaskManage {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/savePointTask", ReplyAction="http://www.artech.com/PointTaskManage/savePointTaskResponse")]
        void savePointTask(string targetcode, double longtitude, double latitude, int priority, System.TimeSpan DetectTime, float maxangle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/deletePointTask", ReplyAction="http://www.artech.com/PointTaskManage/deletePointTaskResponse")]
        void deletePointTask(string tartgetcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/queryPointTask", ReplyAction="http://www.artech.com/PointTaskManage/queryPointTaskResponse")]
        System.Collections.Generic.List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET> queryPointTask();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/queryLastItem_ID", ReplyAction="http://www.artech.com/PointTaskManage/queryLastItem_IDResponse")]
        int queryLastItem_ID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/updatePoint", ReplyAction="http://www.artech.com/PointTaskManage/updatePointResponse")]
        void updatePoint(QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET point);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PointTaskManage/queryTask", ReplyAction="http://www.artech.com/PointTaskManage/queryTaskResponse")]
        System.Collections.Generic.List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPETask> queryTask(System.DateTime starttime, System.DateTime endtime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PointTaskManageChannel : QueryProxy.PointTargetManage.PointTaskManage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PointTaskManageClient : System.ServiceModel.ClientBase<QueryProxy.PointTargetManage.PointTaskManage>, QueryProxy.PointTargetManage.PointTaskManage {
        
        public PointTaskManageClient() {
        }
        
        public PointTaskManageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PointTaskManageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PointTaskManageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PointTaskManageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void savePointTask(string targetcode, double longtitude, double latitude, int priority, System.TimeSpan DetectTime, float maxangle) {
            base.Channel.savePointTask(targetcode, longtitude, latitude, priority, DetectTime, maxangle);
        }
        
        public void deletePointTask(string tartgetcode) {
            base.Channel.deletePointTask(tartgetcode);
        }
        
        public System.Collections.Generic.List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET> queryPointTask() {
            return base.Channel.queryPointTask();
        }
        
        public int queryLastItem_ID() {
            return base.Channel.queryLastItem_ID();
        }
        
        public void updatePoint(QueryProxy.PointTargetManage.DZY_GGFW_DAMPEPOINTTARGET point) {
            base.Channel.updatePoint(point);
        }
        
        public System.Collections.Generic.List<QueryProxy.PointTargetManage.DZY_GGFW_DAMPETask> queryTask(System.DateTime starttime, System.DateTime endtime) {
            return base.Channel.queryTask(starttime, endtime);
        }
    }
}