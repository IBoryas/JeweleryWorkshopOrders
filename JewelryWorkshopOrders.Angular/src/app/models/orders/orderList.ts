  export interface IOrderList {
    id: number;
    product: string;
    client: string;
    employee: string;
    material: string;
    takenWeight: number;
    startDate: Date;
    price: number;
    notes?: string;
  }