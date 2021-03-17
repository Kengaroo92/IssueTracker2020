#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

#COPY ["IssueTracker2020/IssueTracker2020.csproj", "IssueTracker2020/"]
#RUN dotnet restore "IssueTracker2020/IssueTracker2020.csproj"

COPY ["IssueTracker2020.csproj", ""]
RUN dotnet restore "./IssueTracker2020.csproj"

COPY . .

#WORKDIR "/src/IssueTracker2020"
#RUN dotnet build "IssueTracker2020.csproj" -c Release -o /app/build

WORKDIR "/src/."
RUN dotnet build "IssueTracker2020.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IssueTracker2020.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "IssueTracker.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IssueTracker2020.dll