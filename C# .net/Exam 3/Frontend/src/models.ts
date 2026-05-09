export interface User {
    Id?: number;
    UserName: string;
    Email: string;
    UserPassword: string;
    UserRole: string; // Student / Instructor / Admin
    CreatedAt?: Date;
}

export interface Course {
    Id: number;
    Title: string;
    Description: string;
    Price: number;
    CategoryId: number;
    InstructorId: number;
    ImgLink: string;
}

export interface Category {
    Id: number;
    Name: string;
}

export interface Cart {
    Id: number;
    UserId: number;
    CourseId: number;
}

export interface Enrollment {
    Id: number;
    UserId: number;
    CourseId: number;
    Price: number;
    Status: string | null;
    EnrolledDate: string;
}
