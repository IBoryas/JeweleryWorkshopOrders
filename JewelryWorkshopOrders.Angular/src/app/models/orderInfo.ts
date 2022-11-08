export interface IOrder{
    id: number,
    clientFullName:string,
    employeeId: number,
    productId: number,
    productTypeId:number,
    materialId: number,
    materialTypeId: number,
    takenWeight: number,
    price: number,
    notes: string
}