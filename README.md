# 🚀 .NET 10 CI/CD Pipeline with GitHub Actions & Docker Compose

![Docker](https://img.shields.io/badge/Docker-Compose-blue?logo=docker)
![.NET](https://img.shields.io/badge/.NET-10.0-purple?logo=dotnet)
![GitHub Actions](https://img.shields.io/badge/GitHub-Actions-2088FF?logo=githubactions&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A minimal example project that demonstrates how to containerize a **.NET 10 Minimal Web API** and wire it into a CI/CD pipeline using **GitHub Actions** and **Docker Compose**.

This repository provides:

- A sample web API (minimal API style)
- A Dockerfile (multi-stage optimized build)
- A Docker Compose configuration for local development
- A future-ready foundation for CI/CD workflows

---

## 📂 Project Structure

```text
.
├── app/
│ └── src/
│ ├── MyCiCdApp.csproj
│ └── Program.cs
├── Dockerfile
├── docker-compose.yml
└── .github/
└── workflows/
├── ci.yml # build + test (future)
└── deploy.yml # deploy pipeline (future)
```

---

## 🧪 Running Locally (Docker Compose)

### Build & start the container

```bash
docker compose up --build
```

### Stop containers

```bash
docker compose down
```

## API Endpoints

| Method | Route           | Description                  |
| ------ | --------------- | ---------------------------- |
| GET    | `/`             | Returns greeting + timestamp |
| GET    | `/health`       | Health check endpoint        |
| GET    | `/greet/{name}` | Example route with parameter |
| GET    | `/swagger`      | API UI (Swagger/OpenAPI)     |

### Open in browser:

```bash
http://localhost:8000/
http://localhost:8000/health
http://localhost:8000/swagger
```

## Dockerfile Overview

Multi-stage build for optimized production images:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
# restore, publish, copy to runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
ENTRYPOINT ["dotnet", "MyCiCdApp.dll"]
```

## Requirements

| Tool           | Version |
| -------------- | ------- |
| .NET SDK       | 10.0+   |
| Docker         | latest  |
| Docker Compose | v2+     |
| GitHub Actions | enabled |

## CI/CD Roadmap

| Stage                      | Status     |
| -------------------------- | ---------- |
| CI build & unit tests      | 🟡 planned |
| GHCR container registry    | 🟡 planned |
| Deploy via SSH to server   | 🟡 planned |
| Health-check based rollout | 🟡 planned |

Example future steps:

```yaml
docker compose build
docker compose push
ssh into server -> docker compose pull -> up -d
```

## License

MIT License © 2025 Steven Wallace
