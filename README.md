# ANPR Application

A demonstration Automatic Number Plate Recognition (ANPR) application

This project demonstrates an alternative approach to ANPR by using the Qwen Vision Language Model
to identify vehicle registration numbers from images. Traditional OCR could also be integrated,
allowing comparison of recognition
accuracy between OCR and modern multimodal AI models.

# Built using:

- Blazor
- ASP.NET Core
- Entity Framework Core
- Ollama
- Qwen Vision Model

# Features

- Upload vehicle images
- Extract registration numbers using AI vision
- Store parking registrations
- Calculate parking charges
- Simulate payment process
- View currently parked vehicles
- View parking history

# Technologies

- .NET 11
- Blazor
- SQL Server
- Entity Framework Core
- Ollama
- qwen2.5vl:7b

# Running Locally

- Clone the repository
- Configure SQL Server connection string
- Publish the database project
- Start Ollama
- Pull the Qwen model
- Run the application
- Upload images showing only the vehicle registration number