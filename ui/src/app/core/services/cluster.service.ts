import { Injectable } from "@angular/core";
import { ClusterInfo } from "../../models/cluster-info.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ClusterService {

// Set your API base URL (adjust as needed)
    private baseUrl = 'http://localhost:5219/api/Cluster/info';

    constructor(private http: HttpClient) {}

    getClusterInfo(): Observable<ClusterInfo> {
        return this.http.get<ClusterInfo>(this.baseUrl);
    }
}