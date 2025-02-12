import { MenuItem } from './menu.model';

export const MENU: MenuItem[] = [
  {
    label: 'Proxima Host',
    isTitle: true
  },
  {
    label: 'Dashboard',
    icon: 'home',
    link: '/dashboard'
  },
  {
    label: 'Registry',
    icon: 'layers',
    subItems: [
      {
        label: 'Explore',
        link: '/registry/explore'
      },
      {
        label: 'Settings',
        link: '/registry/settings'
      }
    ]
  },
  {
    label: 'Services',
    icon: 'grid',
    link: '/services'
  },
  {
    label: 'Environments',
    icon: 'server',
    subItems: [
      {
        label: 'Functions',
        link: '/environments/functions'
      },
      {
        label: 'Secrets',
        link: '/environments/secrets'
      }
    ]
  },
  {
    label: 'Analytics',
    icon: 'bar-chart-2',
    link: '/analytics'
  },
  {
    label: 'Logs',
    icon: 'file-text',
    link: '/logs'
  },
  {
    label: 'Host Settings',
    icon: 'settings',
    link: '/settings'
  },
  {
    label: 'Info',
    icon: 'info',
    link: '/info'
  },
  // {
  //   label: 'Authentication',
  //   icon: 'unlock',
  //   subItems: [
  //     {
  //       label: 'Login',
  //       link: '/auth/login',
  //     }
  //   ]
  // },
  // {
  //   label: 'Error',
  //   icon: 'cloud-off',
  //   subItems: [
  //     {
  //       label: '404',
  //       link: '/error/404',
  //     },
  //     {
  //       label: '500',
  //       link: '/error/500',
  //     },
  //   ]
  // },
];
