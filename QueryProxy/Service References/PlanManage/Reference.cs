﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueryProxy.PlanManage {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DZY_GGFW_DAMPEPLAN", Namespace="http://schemas.datacontract.org/2004/07/CommonService.Model")]
    [System.SerializableAttribute()]
    public partial class DZY_GGFW_DAMPEPLAN : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ENDTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISSIMULATEDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PLANIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PLANTYPEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PROPOSEPERSONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PROPOSETIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string REMARKField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime STARTTIMEField;
        
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
        public string ISSIMULATED {
            get {
                return this.ISSIMULATEDField;
            }
            set {
                if ((object.ReferenceEquals(this.ISSIMULATEDField, value) != true)) {
                    this.ISSIMULATEDField = value;
                    this.RaisePropertyChanged("ISSIMULATED");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PLANID {
            get {
                return this.PLANIDField;
            }
            set {
                if ((object.ReferenceEquals(this.PLANIDField, value) != true)) {
                    this.PLANIDField = value;
                    this.RaisePropertyChanged("PLANID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PLANTYPE {
            get {
                return this.PLANTYPEField;
            }
            set {
                if ((object.ReferenceEquals(this.PLANTYPEField, value) != true)) {
                    this.PLANTYPEField = value;
                    this.RaisePropertyChanged("PLANTYPE");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.artech.com", ConfigurationName="PlanManage.PlanManage")]
    public interface PlanManage {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PlanManage/insertOrUpdatePlan", ReplyAction="http://www.artech.com/PlanManage/insertOrUpdatePlanResponse")]
        void insertOrUpdatePlan(QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PlanManage/deletePlan", ReplyAction="http://www.artech.com/PlanManage/deletePlanResponse")]
        void deletePlan(QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PlanManage/queryPlan", ReplyAction="http://www.artech.com/PlanManage/queryPlanResponse")]
        QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN queryPlan(string planid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/PlanManage/queryPlanID", ReplyAction="http://www.artech.com/PlanManage/queryPlanIDResponse")]
        System.Collections.Generic.List<string> queryPlanID(System.DateTime starttime, System.DateTime endtime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PlanManageChannel : QueryProxy.PlanManage.PlanManage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlanManageClient : System.ServiceModel.ClientBase<QueryProxy.PlanManage.PlanManage>, QueryProxy.PlanManage.PlanManage {
        
        public PlanManageClient() {
        }
        
        public PlanManageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlanManageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlanManageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlanManageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void insertOrUpdatePlan(QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan) {
            base.Channel.insertOrUpdatePlan(plan);
        }
        
        public void deletePlan(QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN plan) {
            base.Channel.deletePlan(plan);
        }
        
        public QueryProxy.PlanManage.DZY_GGFW_DAMPEPLAN queryPlan(string planid) {
            return base.Channel.queryPlan(planid);
        }
        
        public System.Collections.Generic.List<string> queryPlanID(System.DateTime starttime, System.DateTime endtime) {
            return base.Channel.queryPlanID(starttime, endtime);
        }
    }
}
