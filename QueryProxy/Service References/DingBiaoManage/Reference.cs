﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueryProxy.DingBiaoManage {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DZY_GGFW_DAMPEDINGBIAOTASK", Namespace="http://schemas.datacontract.org/2004/07/CommonService.Model")]
    [System.SerializableAttribute()]
    public partial class DZY_GGFW_DAMPEDINGBIAOTASK : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ENDTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PLANIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime STARTTIMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TYPEField;
        
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
        public string TYPE {
            get {
                return this.TYPEField;
            }
            set {
                if ((object.ReferenceEquals(this.TYPEField, value) != true)) {
                    this.TYPEField = value;
                    this.RaisePropertyChanged("TYPE");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.artech.com", ConfigurationName="DingBiaoManage.DingBiaoManage")]
    public interface DingBiaoManage {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/DingBiaoManage/insertOrUpdateDingBiao", ReplyAction="http://www.artech.com/DingBiaoManage/insertOrUpdateDingBiaoResponse")]
        void insertOrUpdateDingBiao(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/DingBiaoManage/deleteDingBiao", ReplyAction="http://www.artech.com/DingBiaoManage/deleteDingBiaoResponse")]
        void deleteDingBiao(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/DingBiaoManage/queryDingBiaobyPlanID", ReplyAction="http://www.artech.com/DingBiaoManage/queryDingBiaobyPlanIDResponse")]
        System.Collections.Generic.List<QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK> queryDingBiaobyPlanID(int planid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DingBiaoManageChannel : QueryProxy.DingBiaoManage.DingBiaoManage, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DingBiaoManageClient : System.ServiceModel.ClientBase<QueryProxy.DingBiaoManage.DingBiaoManage>, QueryProxy.DingBiaoManage.DingBiaoManage {
        
        public DingBiaoManageClient() {
        }
        
        public DingBiaoManageClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DingBiaoManageClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DingBiaoManageClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DingBiaoManageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void insertOrUpdateDingBiao(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao) {
            base.Channel.insertOrUpdateDingBiao(dingbiao);
        }
        
        public void deleteDingBiao(QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK dingbiao) {
            base.Channel.deleteDingBiao(dingbiao);
        }
        
        public System.Collections.Generic.List<QueryProxy.DingBiaoManage.DZY_GGFW_DAMPEDINGBIAOTASK> queryDingBiaobyPlanID(int planid) {
            return base.Channel.queryDingBiaobyPlanID(planid);
        }
    }
}