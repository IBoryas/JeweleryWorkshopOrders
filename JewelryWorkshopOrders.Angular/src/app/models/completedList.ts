export interface ICompletedOrder {
    id: number;
    product: string;
    client: string;
    employee: string;
    material: string;
    takenWeight: number;
    startDate: Date;
    endDate: Date;
    price: number;
    notes?: string;
  }