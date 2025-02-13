import { Injectable } from "@angular/core";
import { ClusterInfo } from "../../models/cluster-info.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ClusterService {

// Set your API base URL (adjust as needed)
    private baseUrl = environment.apiUrl + '/Cluster/info';

    constructor(private http: HttpClient) {}

    getClusterInfo(): Observable<ClusterInfo> {
        return this.http.get<ClusterInfo>(this.baseUrl);
    }
}