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

Open the solution and build the application. After the successful build run, you can run bruno.WebAPI

# Solution
-	.NET 8 / Mapster / XUnit 
-	Using CQRS & MediatR following Clean Architecture & DDD 

![image](https://github.com/user-attachments/assets/1a9cb896-6c4f-469d-b956-819a478ec19c)

### Application  
- `Application`: Commands e Command Handler / Queries
  
![image](https://github.com/user-attachments/assets/904a7264-e2bd-4f03-8e34-54f3ebc5d9bf)

### Domain / Business Rules 
- `Domain`: Entities / Value Objects / Interfaces
  
![image](https://github.com/user-attachments/assets/cec4c8fa-5854-4e44-a674-74d5774c83e2)

### Infrastructure
- `Infrastructure`: Fake Repository

![image](https://github.com/user-attachments/assets/a4501be9-85b4-4749-9963-0ce9bb921cb9)

# Swagger UI 
![image](https://github.com/user-attachments/assets/bf234ae2-18cf-4152-a2c9-f8d2e6b68766)

![image](https://github.com/user-attachments/assets/467eb733-3fbf-4f6d-b439-a90247378a46)

# Fake BlogPost Data (Default List)
![image](https://github.com/user-attachments/assets/f29e3c0b-6e5c-476c-a89c-d2c138ac9ef5)


# Tests cover some rules requirements 
-	ApplicationTests / DomainTests 

![image](https://github.com/user-attachments/assets/35c99a72-e70d-4fa4-8fb2-e4b4add73555)


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
