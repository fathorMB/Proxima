import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { ClusterService } from '../../../core/services/cluster.service';
import { Cluster } from '../../../models/cluster-info.model';

@Component({
  selector: 'app-info',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {
  clusterInfo: Cluster | null = null;
  errorMessage: string = '';

  constructor(private clusterService: ClusterService) {}

  ngOnInit(): void {
    this.getClusterInfo();
  }

  getClusterInfo(): void {
    this.clusterService.getClusterInfo()
      .subscribe({
        next: (data) => { 
          this.clusterInfo = data
          console.log(this.clusterInfo); 
        },
        error: (error) => {
          console.error('Error fetching cluster info:', error);
          this.errorMessage = 'Error fetching cluster info';
        }
      });
  }
}
