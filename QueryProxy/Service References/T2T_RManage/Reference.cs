﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueryProxy.T2T_RManage {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DZY_GGFW_DAMPETASKTARGET_R", Namespace="http://schemas.datacontract.org/2004/07/CommonService.Model")]
    [System.SerializableAttribute()]
    public partial class DZY_GGFW_DAMPETASKTARGET_R : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TARGETIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TASKIDField;
        
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
        public int TARGETID {
            get {
                return this.TARGETIDField;
            }
            set {
                if ((this.TARGETIDField.Equals(value) != true)) {
                    this.TARGETIDField = value;
                    this.RaisePropertyChanged("TARGETID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TASKID {
            get {
                return this.TASKIDField;
            }
            set {
                if ((this.TASKIDField.Equals(value) != true)) {
                    this.TASKIDField = value;
                    this.RaisePropertyChanged("TASKID");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.artech.com", ConfigurationName="T2T_RManage.TaskTarget_RManage")]
    public interface TaskTarget_RManage {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/TaskTarget_RManage/insertOrUpdateRelation", ReplyAction="http://www.artech.com/TaskTarget_RManage/insertOrUpdateRelationResponse")]
        void insertOrUpdateRelation(QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/TaskTarget_RManage/deleteRelation", ReplyAction="http://www.artech.com/TaskTarget_RManage/deleteRelationResponse")]
        void deleteRelation(QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/TaskTarget_RManage/queryTargetName", ReplyAction="http://www.artech.com/TaskTarget_RManage/queryTargetNameResponse")]
        System.Collections.Generic.List<string> queryTargetName(int taskid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaskTarget_RManageChannel : QueryProxy.T2T_RManage.TaskTarget_RManage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskTarget_RManageClient : System.ServiceModel.ClientBase<QueryProxy.T2T_RManage.TaskTarget_RManage>, QueryProxy.T2T_RManage.TaskTarget_RManage {
        
        public TaskTarget_RManageClient() {
        }
        
        public TaskTarget_RManageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskTarget_RManageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskTarget_RManageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskTarget_RManageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void insertOrUpdateRelation(QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation) {
            base.Channel.insertOrUpdateRelation(relation);
        }
        
        public void deleteRelation(QueryProxy.T2T_RManage.DZY_GGFW_DAMPETASKTARGET_R relation) {
            base.Channel.deleteRelation(relation);
        }
        
        public System.Collections.Generic.List<string> queryTargetName(int taskid) {
            return base.Channel.queryTargetName(taskid);
        }
    }
}
