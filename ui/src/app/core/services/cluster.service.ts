import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Cluster } from "../../models/cluster-info.model";

@Injectable({
  providedIn: 'root'
})
export class ClusterService {

// Set your API base URL (adjust as needed)
    private baseUrl = environment.apiUrl + '/Cluster/info';

    constructor(private http: HttpClient) {}

    getClusterInfo(): Observable<Cluster> {
        return this.http.get<Cluster>(this.baseUrl);
    }
}