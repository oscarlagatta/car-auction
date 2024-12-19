# Microservices Car Auction Application with .NET and Next.js

This project is a microservices-based application using **.NET** for backend services and **Next.js** for the frontend client. The application is deployed to a Kubernetes cluster on the internet.

## Features

This project includes the following features:

- **Backend Services**: Multiple services built using .NET to provide core app functionality.
- **Service-to-Service Communication**: Integration via **RabbitMQ** and **gRPC**.
- **Authentication and Authorization**: Managed using **IdentityServer** as the identity provider.
- **API Gateway**: A gateway built using **Microsoft YARP**.
- **Frontend Application**: A client-side app built with **Next.js** using the new **App Router** functionality introduced in Next.js 13.4.
- **Real-Time Communication**: Push notifications implemented with **SignalR**.
- **Containerization**: All services containerized using **Docker**.
- **CI/CD Workflows**: Automated workflows using **GitHub Actions**.
- **Ingress Controllers**: To manage external access to the services.
- **Local Deployment**: Full application deployment locally using **Docker Compose**.

## Project Goals

The primary goal of this project is to create a fully functional microservices-based application that can be run and deployed locally without requiring any paid cloud services. This provides flexibility for development, testing.

## Additional Deployment Options

After completing the main setup, the project includes optional steps for further enhancements:

1. **Unit and Integration Testing**: Guidelines for testing individual components and integrated systems.
2. **Local Kubernetes Deployment**: Publishing the app to a local Kubernetes cluster.
3. **Cloud Kubernetes Deployment**: Publishing the app to an internet-facing Kubernetes cluster.
