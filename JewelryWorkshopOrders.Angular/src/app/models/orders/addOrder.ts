export interface IAddOrder{
    firstName: string,
    lastName: string,
    patronymic: string,
    phoneNumber: number;
    employeeId: number,
    productId: number,
    productTypeId:number,
    materialId: number,
    materialTypeId: number,
    takenWeight: number,
    price: number,
    notes: string
}