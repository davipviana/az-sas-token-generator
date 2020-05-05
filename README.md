# Azure SAS Token Generator

.NET Core Console Application to generate a **Shared Access Signature token** (more information in [Azure Documentation](https://docs.microsoft.com/bs-latn-ba/azure/service-bus-messaging/service-bus-sas#generate-a-shared-access-signature-token)) to access a Service Bus messaging.

## Getting Started

### Prerequisites

- .NET Core 3.1

### Update Host Name, Policy Name, Policy Key and Queue Name

1. Open **appsettings.json**.
2. Replace **yourservicebus.servicebus.windows.net** with the host name of your Service Bus instance.
3. Replace **YourPolicyName** with the name of the policy rule.
4. Replace **YourPolicyKey** with the key (Primary of Secondary) related to the policy.
5. Replace **yourQueueName** with the name of the queue that you want to acess

## Run the Sample
Run the application and after the config check the SAS token will be generated and displayed in console.

## License

Azure SAS Token Generator is open source software [licensed as MIT](https://github.com/davipviana/az-sas-token-generator/blob/master/LICENSE).