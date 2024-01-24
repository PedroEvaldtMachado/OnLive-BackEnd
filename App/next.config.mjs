/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      { protocol: 'https', hostname: '**.example.com', port: '' },
      { protocol: 'https', hostname: '**.cloudinary.com', port: '' },
      { protocol: 'https', hostname: '**.googleusercontent.com', port: '' },
    ]
  },
};

export default nextConfig;
