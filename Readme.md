# How to run
dotnet run --project C:\max-projects\ivmmarkets\src\GraphCalc\GraphCalc.csproj

# What is it ?
Simple emulation of microservices architecture.
It's not ready for production solution. It just explains how can it be implemented.

`FakeMessageBus` - plays Queue role
`FabService...ResultSaverService` - play microservices role. In production it could be separate project or something that we can deploy independently
`Messages.cs` - contains messages with help of which microservices can communicate.