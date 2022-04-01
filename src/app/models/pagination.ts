export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}

export class PeginationResult<T> {
  result: T;
  pagination: Pagination;
}
