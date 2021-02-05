#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AutomakerQuiz.Application/AutomakerQuiz.Application.csproj", "AutomakerQuiz.Application/"]
COPY ["AutomakerQuiz.Infra.CrossCutting/AutomakerQuiz.Infra.CrossCutting.csproj", "AutomakerQuiz.Infra.CrossCutting/"]
COPY ["AutomakerQuiz.Infra.Data/AutomakerQuiz.Infra.Data.csproj", "AutomakerQuiz.Infra.Data/"]
COPY ["AutomakerQuiz.Domain/AutomakerQuiz.Domain.csproj", "AutomakerQuiz.Domain/"]
COPY ["AutomakerQuiz.Service/AutomakerQuiz.Service.csproj", "AutomakerQuiz.Service/"]
COPY ["Infra.Shared/Infra.Shared.csproj", "Infra.Shared/"]
RUN dotnet restore "AutomakerQuiz.Application/AutomakerQuiz.Application.csproj"
COPY . .
WORKDIR "/src/AutomakerQuiz.Application"
RUN dotnet build "AutomakerQuiz.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutomakerQuiz.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutomakerQuiz.Application.dll"]