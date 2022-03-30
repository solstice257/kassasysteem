FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Backend/WalkingSkeletonKassaSysteem/*.csproj .
RUN dotnet restore "./WalkingSkeletonKassaSysteem.csproj"
COPY . .
#WORKDIR "/src/."
#RUN dotnet build "WalkingSkeletonKassaSysteem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WalkingSkeletonKassaSysteem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WalkingSkeletonKassaSysteem.dll"]


