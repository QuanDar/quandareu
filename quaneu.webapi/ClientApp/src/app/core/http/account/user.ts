export interface IUser {
    id: number;
    userName: string;
    normalizedUserName: string;
    email: string;
    normalizedEmail: string;
    passwordHash: string;
    securityStamp: string;
    concurrencyStamp: string;
    phoneNumber: number;
    phoneNumberConfirmed: boolean;
    twoFactorEnabled: boolean;
    lockoutEnd: boolean;
    lockoutEnabled: boolean;
    accessFailedCount: number;
}