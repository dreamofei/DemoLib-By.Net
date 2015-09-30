﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Eland.BBSS_Sale.com/services", ConfigurationName="ServiceReference2.TokenServiceWSSoap")]
    public interface TokenServiceWSSoap {
        
        // CODEGEN: 命名空间 http://Eland.BBSS_Sale.com/services 的元素名称 UserId 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://Eland.BBSS_Sale.com/services/CreateToken", ReplyAction="*")]
        ConsoleApplication1.ServiceReference2.CreateTokenResponse CreateToken(ConsoleApplication1.ServiceReference2.CreateTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Eland.BBSS_Sale.com/services/CreateToken", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CreateTokenResponse> CreateTokenAsync(ConsoleApplication1.ServiceReference2.CreateTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Eland.BBSS_Sale.com/services/CheckToken", ReplyAction="*")]
        ConsoleApplication1.ServiceReference2.CheckTokenResponse CheckToken(ConsoleApplication1.ServiceReference2.CheckTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Eland.BBSS_Sale.com/services/CheckToken", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CheckTokenResponse> CheckTokenAsync(ConsoleApplication1.ServiceReference2.CheckTokenRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateToken", Namespace="http://Eland.BBSS_Sale.com/services", Order=0)]
        public ConsoleApplication1.ServiceReference2.CreateTokenRequestBody Body;
        
        public CreateTokenRequest() {
        }
        
        public CreateTokenRequest(ConsoleApplication1.ServiceReference2.CreateTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Eland.BBSS_Sale.com/services")]
    public partial class CreateTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string UserId;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int expiredDuration;
        
        public CreateTokenRequestBody() {
        }
        
        public CreateTokenRequestBody(string UserId, int expiredDuration) {
            this.UserId = UserId;
            this.expiredDuration = expiredDuration;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateTokenResponse", Namespace="http://Eland.BBSS_Sale.com/services", Order=0)]
        public ConsoleApplication1.ServiceReference2.CreateTokenResponseBody Body;
        
        public CreateTokenResponse() {
        }
        
        public CreateTokenResponse(ConsoleApplication1.ServiceReference2.CreateTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Eland.BBSS_Sale.com/services")]
    public partial class CreateTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CreateTokenResult;
        
        public CreateTokenResponseBody() {
        }
        
        public CreateTokenResponseBody(string CreateTokenResult) {
            this.CreateTokenResult = CreateTokenResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckToken", Namespace="http://Eland.BBSS_Sale.com/services", Order=0)]
        public ConsoleApplication1.ServiceReference2.CheckTokenRequestBody Body;
        
        public CheckTokenRequest() {
        }
        
        public CheckTokenRequest(ConsoleApplication1.ServiceReference2.CheckTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Eland.BBSS_Sale.com/services")]
    public partial class CheckTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string token;
        
        public CheckTokenRequestBody() {
        }
        
        public CheckTokenRequestBody(string token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckTokenResponse", Namespace="http://Eland.BBSS_Sale.com/services", Order=0)]
        public ConsoleApplication1.ServiceReference2.CheckTokenResponseBody Body;
        
        public CheckTokenResponse() {
        }
        
        public CheckTokenResponse(ConsoleApplication1.ServiceReference2.CheckTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://Eland.BBSS_Sale.com/services")]
    public partial class CheckTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CheckTokenResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string userId;
        
        public CheckTokenResponseBody() {
        }
        
        public CheckTokenResponseBody(string CheckTokenResult, string userId) {
            this.CheckTokenResult = CheckTokenResult;
            this.userId = userId;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TokenServiceWSSoapChannel : ConsoleApplication1.ServiceReference2.TokenServiceWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TokenServiceWSSoapClient : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference2.TokenServiceWSSoap>, ConsoleApplication1.ServiceReference2.TokenServiceWSSoap {
        
        public TokenServiceWSSoapClient() {
        }
        
        public TokenServiceWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TokenServiceWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenServiceWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenServiceWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleApplication1.ServiceReference2.CreateTokenResponse ConsoleApplication1.ServiceReference2.TokenServiceWSSoap.CreateToken(ConsoleApplication1.ServiceReference2.CreateTokenRequest request) {
            return base.Channel.CreateToken(request);
        }
        
        public string CreateToken(string UserId, int expiredDuration) {
            ConsoleApplication1.ServiceReference2.CreateTokenRequest inValue = new ConsoleApplication1.ServiceReference2.CreateTokenRequest();
            inValue.Body = new ConsoleApplication1.ServiceReference2.CreateTokenRequestBody();
            inValue.Body.UserId = UserId;
            inValue.Body.expiredDuration = expiredDuration;
            ConsoleApplication1.ServiceReference2.CreateTokenResponse retVal = ((ConsoleApplication1.ServiceReference2.TokenServiceWSSoap)(this)).CreateToken(inValue);
            return retVal.Body.CreateTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CreateTokenResponse> ConsoleApplication1.ServiceReference2.TokenServiceWSSoap.CreateTokenAsync(ConsoleApplication1.ServiceReference2.CreateTokenRequest request) {
            return base.Channel.CreateTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CreateTokenResponse> CreateTokenAsync(string UserId, int expiredDuration) {
            ConsoleApplication1.ServiceReference2.CreateTokenRequest inValue = new ConsoleApplication1.ServiceReference2.CreateTokenRequest();
            inValue.Body = new ConsoleApplication1.ServiceReference2.CreateTokenRequestBody();
            inValue.Body.UserId = UserId;
            inValue.Body.expiredDuration = expiredDuration;
            return ((ConsoleApplication1.ServiceReference2.TokenServiceWSSoap)(this)).CreateTokenAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleApplication1.ServiceReference2.CheckTokenResponse ConsoleApplication1.ServiceReference2.TokenServiceWSSoap.CheckToken(ConsoleApplication1.ServiceReference2.CheckTokenRequest request) {
            return base.Channel.CheckToken(request);
        }
        
        public string CheckToken(string token, out string userId) {
            ConsoleApplication1.ServiceReference2.CheckTokenRequest inValue = new ConsoleApplication1.ServiceReference2.CheckTokenRequest();
            inValue.Body = new ConsoleApplication1.ServiceReference2.CheckTokenRequestBody();
            inValue.Body.token = token;
            ConsoleApplication1.ServiceReference2.CheckTokenResponse retVal = ((ConsoleApplication1.ServiceReference2.TokenServiceWSSoap)(this)).CheckToken(inValue);
            userId = retVal.Body.userId;
            return retVal.Body.CheckTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CheckTokenResponse> ConsoleApplication1.ServiceReference2.TokenServiceWSSoap.CheckTokenAsync(ConsoleApplication1.ServiceReference2.CheckTokenRequest request) {
            return base.Channel.CheckTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsoleApplication1.ServiceReference2.CheckTokenResponse> CheckTokenAsync(string token) {
            ConsoleApplication1.ServiceReference2.CheckTokenRequest inValue = new ConsoleApplication1.ServiceReference2.CheckTokenRequest();
            inValue.Body = new ConsoleApplication1.ServiceReference2.CheckTokenRequestBody();
            inValue.Body.token = token;
            return ((ConsoleApplication1.ServiceReference2.TokenServiceWSSoap)(this)).CheckTokenAsync(inValue);
        }
    }
}