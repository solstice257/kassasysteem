FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Backend/Kassasysteem/Order.Microservice/ ./Order.Microservice
RUN ls
RUN dotnet restore "./Order.Microservice/Order.Microservice.csproj"
COPY Backend/Kassasysteem/Order.Microservice.Test/ ./Order.Microservice.Test
RUN dotnet restore "./Order.Microservice.Test/Order.Microservice.Test.csproj"
COPY /Backend .
WORKDIR /src
RUN dotnet build "./Order.Microservice/Order.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Order.Microservice/Order.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Microservice.dll"]