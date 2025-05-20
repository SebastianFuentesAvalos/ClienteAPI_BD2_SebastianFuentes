# ClienteAPI - Proyecto BD2 Sebastian Fuentes

## Descripción

API para gestión de clientes con métricas Prometheus y HealthChecks para base de datos SQL Server. Integración con Docker, Prometheus y Grafana para monitoreo.

## Características

- API RESTful en .NET 6
- HealthChecks para base de datos
- Métricas personalizadas expuestas en `/metrics`
- Dockerizado con archivos para CI/CD (buildimage.yml, delivery.yml)
- Monitoreo con Prometheus y visualización en Grafana

## Requisitos

- .NET 6 SDK
- Docker
- Docker Compose
- Git
- Prometheus y Grafana configurados

## Cómo ejecutar localmente

1. Configurar la cadena de conexión en `appsettings.json` o en las variables de entorno.
2. Ejecutar la API:

```bash
dotnet run