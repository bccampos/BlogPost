# Problem - BlogPost requirements
Data Models:
- Create two data models: BlogPost and Comment. A BlogPost has a title and
content, and each BlogPost can have multiple Comment objects associated with
it.
API Endpoints:
- Implement the following API endpoints:
- GET /api/posts: This endpoint should return a list of all blog posts,
including their titles and the number of comments associated with each
post.
- POST /api/posts: Create a new blog post.
- GET /api/posts/{id}: Retrieve a specific blog post by its ID, including its
title, content, and a list of associated comments.
- POST /api/posts/{id}/comments: Add a new comment to a specific blog
post.

## How to use and run the project

Open the solution and build the application. After the successful build run, you can run bruno.Prosigliere.WebAPI

# Solution
-	.NET 8 / Mapster / XUnit 
-	Using CQRS & MediatR following Clean Architecture & DDD 

![image](https://github.com/user-attachments/assets/6900a414-299f-4b77-806f-54c7f772f7c0)

### Application  
- `Application`: Commands e Command Handler / Queries
  
![image](https://github.com/user-attachments/assets/5c4cece3-d845-4776-83be-f6212cc0dd8e)

### Domain / Business Rules 
- `Domain`: Entities / Value Objects / Interfaces
  
![image](https://github.com/user-attachments/assets/3bc93542-14f4-4691-b11e-8c7ea2a93d14)

### Infrastructure
- `Infrastructure`: Fake Repository

![image](https://github.com/user-attachments/assets/fd8885b5-ae84-4e08-ac56-e7d2d3485569)

# Swagger UI 
![image](https://github.com/user-attachments/assets/b3e2159b-8cc9-494e-9f12-1d07f74812bf)

![image](https://github.com/user-attachments/assets/843ddcc1-fdd4-4d02-b240-9389ebbf29d0)

# Fake BlogPost Data (Default List)
![image](https://github.com/user-attachments/assets/47e3c6f7-d3ab-4a63-a31c-3ea4aaf1b1e8)

# Tests cover some rules requirements 
-	ApplicationTests / DomainTests 

![image](https://github.com/user-attachments/assets/93dac44a-cea3-475f-836d-163b0be4e276)

# Improvements 
### New Layer
-	Create a new layer for Contracts / DTO response
### Application
-	Add error handling to return error codes and messages for common issues. 
-	Add pagination in GetPostListQuery 
### Domain 
-	Add Validation logic for properties such as Title, Content, Comment
### Infrastructure
-	Replace FakeBlogPostRepository with a database implementation (e.g., EF Core with SQL Server or MongoDB). 
- Use Unit of Work Pattern
### WebAPI 
- Add FluentValidation or DataAnnotations to validate input commands 
- Work with security Authentication and Authorization 
### XUnit - Testing
- Add a new layer to test WebAPI 
- Add a new layer to test Architecture - You can check check the dependency like Domain_Should_Not_HaveDependencyOnOtherProjects
